export const GENDERS = [
  { text: 'Kobieta', value: 1 },
  { text: 'Mężczyzna', value: 2 }
];

export const LEVELS = [
  { text: 'Początkujący', value: 1 },
  { text: 'Średnio zaawansowany', value: 2 },
  { text: 'Bardzo zaawansowany', value: 3 },
  { text: 'Profesjonalista', value: 4 }
];

export function levelName(level) {
  switch(level) {
    case 1:
      return 'Początkujący';
    case 2:
      return 'Średnio zaawansowany';
    case 3:
      return 'Bardzo zaawansowany';
    case 4:
      return 'Profesjonalista';
    default: return '-';
  }
}
