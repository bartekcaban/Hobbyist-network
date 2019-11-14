import Vue from 'vue';
import moment from 'moment';

Vue.prototype.moment = moment;

export default (date) => {
  if (!date) {
    return '-';
  }

  return moment(date).format('YYYY-MM-DD');
};