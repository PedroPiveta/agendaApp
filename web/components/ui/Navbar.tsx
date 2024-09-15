import Link from "next/link";
import { Button } from "./button";

export default function Navbar() {
  return (
    <header className="w-full h-24 py-4 px-6 flex items-center justify-end">
        <nav>
            <Link href="/">
                <Button variant="link">Criar conta</Button>
            </Link>
            <Link href="/login">
                <Button>Login</Button>
            </Link>
        </nav>
    </header>
  )
}
