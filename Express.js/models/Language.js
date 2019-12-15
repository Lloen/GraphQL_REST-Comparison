/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Language', {
    language_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    language: {
      type: DataTypes.TEXT,
      allowNull: false
    }
  }, {
    tableName: 'Language'
  });
};
