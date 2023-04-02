import Head from "next/head";
import { useEffect, useState } from "react";

export default function Home() {
  const [data, setData] = useState<{ a: number }>({ a: 0 });

  useEffect(() => {
    const getData = async () => {
      const res = await fetch("https://localhost:7255/homes");
      const data = res.json();
      return data;
    };
    getData().then((data) => setData(data));
  }, []);

  return (
    <>
      <Head>
        <title>Noti</title>
        <meta name="description" content="Generated by Noti" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <>Hello, I am Next.js</> <br />
      <>This is server response: {data.a} (actually 1), but CORS error</>
    </>
  );
}
