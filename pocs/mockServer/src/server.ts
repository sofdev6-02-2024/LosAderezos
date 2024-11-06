import Fastify from 'fastify';
import { loadRoutes } from './loadRoutes';
// @ts-ignore
import cors from '@fastify/cors';

const app = Fastify({ logger: true });

app.register(cors, {
  origin: 'http://localhost:5173',
  methods: ['GET', 'POST', 'PUT', 'DELETE'],
});

app.register(async (appInstance) => {
  await loadRoutes(appInstance);
});

const startServer = async () => {
  try {
    await app.listen({ port: 3000 });
    console.log(`Server running at http://localhost:3000`);
  } catch (err) {
    app.log.error(err);
    process.exit(1);
  }
};

startServer();
