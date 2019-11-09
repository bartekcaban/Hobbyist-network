import client from '@/plugins/axios';

export default {
  async registerUser(user) {
    const resource = '/user/register';
    const result = await client.post(resource, {
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      password: user.password,
      confirmPassword: user.confirmPassword,
      description: user.description,
      gender: user.gender,
      city: user.city,
      dateOfBirth: user.dateOfBirth,
      phoneNumber: user.phoneNumber,
    });
    return result.data.result;
  },
  async loginUser(user) {
    const resource = '/user/login';
    const result = await client.get(resource, {
      email: user.email,
      password: user.password,
    });
    return result.data.result;
  },
  async updateUser(user) {
    const resource = `/user/update/${user.id}`;
    const result = await client.put(resource, {
      firstName: user.firstName,
      lastName: user.lastName,
      description: user.description,
      gender: user.gender,
      city: user.city,
      dateOfBirth: user.dateOfBirth,
      phoneNumber: user.phoneNumber,
    });
    return result.data.result;
  },
};
