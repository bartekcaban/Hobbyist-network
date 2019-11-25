import service from './service/service';
import { date, dateTime} from '@/shared/moment';

export default {
  async registerUser(state, user) {
    await service.registerUser(user);
  },
  async loginUser({ commit }, user) {
    const result = await service.loginUser(user);
    result.dateOfBirth = date(result.dateOfBirth);
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
    result.dateOfBirth = date(result.dateOfBirth);
    commit('setCurrentUserInLocalStorage', result);
    commit('setCurrentUser', result);
  },
  async getEvents({ commit }) {
    const result = await service.getEvents();
    result.forEach(event => {
    event.startDate = dateTime(event.startDate);
    event.endDate = dateTime(event.endDate);
    });
    commit('setEvents', result);
  },
  async getCurrentUserEvents({ commit }, id) {
    const result = await service.getEventsByUserId(id);
    result.forEach(event => {
      event.startDate = dateTime(event.startDate);
      event.endDate = dateTime(event.endDate);
      });
    commit('setCurrentUserEvents', result);
  },
  async addEvent(state, event) {
    await service.addEvent(event);
  },
  async editEvent(state, event) {
    await service.editEvent(event);
  },
  async deleteEvent(state, id) {
    await service.deleteEvent(id);
  },
};