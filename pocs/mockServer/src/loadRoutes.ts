import { FastifyInstance, HTTPMethods } from 'fastify';
import fs from 'fs';
import path from 'path';

interface MockRouteConfig {
  endpoint: string;
  method: 'get' | 'post' | 'put' | 'delete';
  body?: Record<string, any>;
  response: Record<string, any>;
  responseStatus: number;
}

export async function loadRoutes(app: FastifyInstance) {
  const configPath = path.join(__dirname, 'config', 'mock-config.json');
  const rawData = fs.readFileSync(configPath, 'utf-8');
  const routes: MockRouteConfig[] = JSON.parse(rawData);

  routes.forEach(route => {
    app.route({
      method: route.method.toUpperCase() as HTTPMethods,
      url: route.endpoint,
      handler: async (request, reply) => {
        const { body } = request;

        // Check if the request body matches the mock configuration, in case it was configured
                
        if (route.body && JSON.stringify(body) !== JSON.stringify(route.body)) {
          reply.status(400).send({ error: 'Request body does not match expected format.' });
        } else {
          reply.status(route.responseStatus).send(route.response);
        }
      }
    });
  });
}
