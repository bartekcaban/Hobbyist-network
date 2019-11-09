import axios from 'axios';

const api = axios.create({
  baseURL: "https://localhost:44375/api",
});

const client = {
  async get(resource, params) {
    const config = {
      params,
    };

    return api.get(resource, config);
  },
  async post(resource, data, params) {
    const config = {
      params,
    };

    return api.post(resource, data, config);
  },
  async put(resource, data, params) {
    const config = {
      params,
    };
    return api.put(resource, data, config);
  },
  async delete(resource, params) {
    const config = {
      params,
    };

    return api.delete(resource, config);
  },
};

export default client;
