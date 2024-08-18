'use client';

import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import { useEffect, useState } from "react";

export default function Home() {
  const [date, setDate] = useState<Date | undefined>(new Date())

  useEffect(() => {
    console.log('date:', date?.toISOString());
  } , [date]);

  return (
    <main>
      <Calendar
        mode="single"
        selected={date}
        onSelect={setDate}
        className="rounded-md border"
      />
      <Button>Click me</Button>
    </main>
  );
}
