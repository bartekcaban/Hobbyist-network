import Vue from 'vue';
import moment from 'moment';

Vue.prototype.moment = moment;

export function date (date) {
  if (!date) {
    return '-';
  }

  return moment(date).format('YYYY-MM-DD');
}

export function dateTime (date) {
  if (!date) {
    return '-';
  }
  
  return moment(date).format('YYYY-MM-DD HH:mm');
}
