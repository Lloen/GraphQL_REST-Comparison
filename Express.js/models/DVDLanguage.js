/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
  return sequelize.define('DVDLanguage', {
    dvd_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'DVD',
        key: 'dvd_id'
      }
    },
    language_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'Language',
        key: 'language_id'
      }
    },
    audio_format_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'AudioFormat',
        key: 'audio_id'
      }
    },
    dvd_language_id: {
      type: DataTypes.INTEGER,
      allowNull: true,
      primaryKey: true
    }
  }, {
    tableName: 'DVDLanguage'
  });
};
