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
    const resource = '/user/update';
    const result = await client.post(resource, {
      id: user.id,
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
  async changePassword(user) {
    const resource = '/user/change-password';
    const result = await client.post(resource, {
      id: user.id,
      password: user.password,
      currentPassword: user.currentPassword,
    });
    return result.data.result;
  },
};
