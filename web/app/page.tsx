"use client";

import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { useState } from "react";

const formSchema = z.object({
  userName: z.string().min(1, { message: "O nome de usuário é obrigatório" }),
  email: z.string().email({ message: "Email inválido" }),
  password: z.string()
    .min(12, { message: "A senha deve ter no mínimo 12 caracteres." })
    .regex(/[0-9]/, { message: "A senha deve conter pelo menos um dígito." })
    .regex(/[a-z]/, { message: "A senha deve conter pelo menos uma letra minúscula." })
    .regex(/[A-Z]/, { message: "A senha deve conter pelo menos uma letra maiúscula." })
    .regex(/[\W_]/, { message: "A senha deve conter pelo menos um caractere especial." }),
  confirmPassword: z.string().min(1, { message: "As senhas não conferem" }),
}).superRefine(({ confirmPassword, password }, ctx) => {
  if (password !== confirmPassword) {
    ctx.addIssue({
      code: "custom",
      message: "As senhas não conferem",
      path: ["confirmPassword"],
    });
  }
});

export default function Home() {
  const [errorMessage, setErrorMessage] = useState<string | any>("");

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      userName: "",
      email: "",
      password: "",
      confirmPassword: ""
    }
  });

  async function onSubmit(values: z.infer<typeof formSchema>) {
    try {
      // Cria um novo objeto omitindo o campo confirmPassword
      const { confirmPassword, ...submissionData } = values;

      const response = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/account/register`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(submissionData),
      });

      if (!response.ok) {
        const errorText = await response.text() || "Erro ao enviar o formulário";
        throw new Error(errorText);
      }

      const data = await response.json();
      console.log("Sucesso:", data);
    } catch (error) {
      console.error("Erro:", error);
      setErrorMessage(error instanceof Error ? error.message : "Erro desconhecido");
    }
  }

  return (
    <main className="container">
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)}>
          <FormField
            control={form.control}
            name="userName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Usuário</FormLabel>
                <FormControl>
                  <Input placeholder="Digite seu nome de usuário" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Email</FormLabel>
                <FormControl>
                  <Input type="email" placeholder="Digite seu email" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="password"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Senha</FormLabel>
                <FormControl>
                  <Input type="password" placeholder="Digite sua senha" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="confirmPassword"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Confirmar Senha</FormLabel>
                <FormControl>
                  <Input type="password" placeholder="Confirme sua senha" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <Button type="submit">Registrar</Button>

          {errorMessage && (
            <div className="text-red-500 mt-4">
              {errorMessage}
            </div>
          )}
        </form>
      </Form>
    </main>
  );
}
