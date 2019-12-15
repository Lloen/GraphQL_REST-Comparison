/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
  const DVD = sequelize.define('DVD', {
    dvd_id: {
      type: DataTypes.INTEGER,
      allowNull: true,
      primaryKey: true
    },
    movie_id: {
      type: DataTypes.INTEGER,
      allowNull: false
    },
    isbn: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    edition: {
      type: DataTypes.TEXT,
      allowNull: true
    },
    region: {
      type: DataTypes.TEXT,
      allowNull: true
    }
  }, {
    tableName: 'DVD',
    timestamps: false
  });

  DVD.associate = function(models) {
    models.DVD.belongsTo(models.Movie,
      { foreignKey: "movie_id" });
  };

  return DVD;
};
