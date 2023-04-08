/** @type {import('next').NextConfig} */
const rewrites = () => {
  return [
    {
      source: "/api/:path*",
      destination: "http://localhost:5204/api/:path*",
    },
  ];
};

const nextConfig = {
  reactStrictMode: true,
  images: {
    loader: "akamai",
    path: "/",
  },
  rewrites,
};

module.exports = nextConfig;
