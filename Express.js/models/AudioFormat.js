/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
  return sequelize.define('AudioFormat', {
    audio_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    format: {
      type: DataTypes.TEXT,
      allowNull: false
    }
  }, {
    tableName: 'AudioFormat'
  });
};
