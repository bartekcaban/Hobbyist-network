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
};