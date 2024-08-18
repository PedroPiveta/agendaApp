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
  password: z.string()
    .min(12, { message: "A senha deve ter no mínimo 12 caracteres." })
    .regex(/[0-9]/, { message: "A senha deve conter pelo menos um dígito." })
    .regex(/[a-z]/, { message: "A senha deve conter pelo menos uma letra minúscula." })
    .regex(/[A-Z]/, { message: "A senha deve conter pelo menos uma letra maiúscula." })
    .regex(/[\W_]/, { message: "A senha deve conter pelo menos um caractere especial." }),
});

export default function Login() {
    const form = useForm<z.infer<typeof formSchema>>({
      resolver: zodResolver(formSchema),
      defaultValues: {
        userName: "",
        password: "",
      }
    });
  
    async function onSubmit(values: z.infer<typeof formSchema>) {
      try {
        const { ...submissionData } = values;
  
        const response = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/account/login`, {
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
  
            <Button type="submit">Fazer login</Button>
          </form>
        </Form>
      </main>
    );
}
