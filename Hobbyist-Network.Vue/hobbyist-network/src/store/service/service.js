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
      instagram: user.instagram,
      facebook: user.facebook,
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
  async getHobbyCategories() {
    const resource = '/hobby-category/get';
    const result = await client.get(resource);
    return result.data.result;
  },
  async addHobby(hobby) {
    const resource = '/hobby/add';
    const result = await client.post(resource, {
      userId: hobby.userId,
      categoryId: hobby.categoryId,
      level: hobby.level,
      description: hobby.description,
    });
    return result.data.result;
  },
  async editHobby(hobby) {
    const resource = '/hobby/update';
    const result = await client.post(resource, {
      id: hobby.id,
      userId: hobby.userId,
      categoryId: hobby.categoryId,
      level: hobby.level,
      description: hobby.description,
    });
    return result.data.result;
  },
  async deleteHobby(id) {
    const resource = `/hobby/delete?id=${id}`;
    const result = await client.delete(resource);
    return result.data.result;
  },
  async getUserById(id) {
    const resource = '/user/get';
    const result = await client.get(resource, {
      id
    });
    return result.data.result;
  },
  async getEventsByUserId(userId) {
    const resource = '/event/get-by-user-id';
    const result = await client.get(resource, {
      userId
    });
    return result.data.result;
  },
  async getEvents() {
    const resource = '/event/get';
    const result = await client.get(resource);
    return result.data.result;
  },
  async deleteEvent(id) {
    const resource = `/event/delete?id=${id}`;
    const result = await client.delete(resource);
    return result.data.result;
  },
  async addEvent(event) {
    const resource = '/event/add';
    const result = await client.post(resource, {
      name: event.name,
      description: event.description,
      localization: event.localization,
      startDate: event.startDate,
      endDate: event.endDate,
      organiserId: event.organiserId,
      categoryId: event.categoryId,
    });
    return result.data.result;
  },
  async editEvent(event) {
    const resource = '/event/update';
    const result = await client.post(resource, {
      id: event.id,
      name: event.name,
      description: event.description,
      localization: event.localization,
      startDate: event.startDate,
      endDate: event.endDate,
      categoryId: event.categoryId,
    });
    return result.data.result;
  },
  async getUsersForCurrentUser(id) {
    const resource = '/user/get-users';
    const result = await client.get(resource, {
      id
    });
    return result.data.result;
  },
  async getMatchedUsersForCurrentUser(id) {
    const resource = '/contact/get';
    const result = await client.get(resource, {
      id
    });
    return result.data.result;
  },
  async notMatch(data) {
    const resource = '/contact/not-match';
    const result = await client.post(resource, {
      userId: data.userId,
      matchedUserId: data.matchedUserId,
    });
    return result.data.result;
  },
  async match(data) {
    const resource = '/contact/match';
    const result = await client.post(resource, {
      userId: data.userId,
      matchedUserId: data.matchedUserId,
    });
    return result.data.result;
  },
  async deleteContact(id) {
    const resource = `/contact/delete?id=${id}`;
    const result = await client.post(resource);
    return result.data.result;
  },
};
