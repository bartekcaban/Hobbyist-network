import service from './service/service';
import dateFormat from '@/shared/moment';

export default {
  async registerUser(state, user) {
    await service.registerUser(user);
  },
  async loginUser({ commit }, user) {
    const result = await service.loginUser(user);
    result.dateOfBirth = dateFormat(result.dateOfBirth);
    commit('setCurrentUserInLocalStorage', result);
    commit('setCurrentUser', result);
  },
  async getUserDetails({ commit }) {
    const result = JSON.parse(localStorage.getItem('currentUser'));
    commit('setCurrentUser', result);
  },
  async updateUser({ commit }, user) {
    await service.updateUser(user);
    commit('setCurrentUserInLocalStorage', user);
  },
  async changePassword(state, user) {
    await service.changePassword(user);
  },
  async getHobbyCategories({ commit }) {
    const result = await service.getHobbyCategories();
    commit('setHobbyCategories', result);
  },
  async addHobby(state, hobby) {
    await service.addHobby(hobby);
  },
  async editHobby(state, hobby) {
    await service.editHobby(hobby);
  },
  async deleteHobby(state, id) {
    await service.deleteHobby(id);
  },
  async getCurrentUser({ commit }, id) {
    const result = await service.getUserById(id);
    commit('setCurrentUserInLocalStorage', result);
    commit('setCurrentUser', result);
  },
};