/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
  const Genre = sequelize.define('Genre', {
    genre_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    genre: {
      type: DataTypes.TEXT,
      allowNull: false
    }
  }, {
    tableName: 'Genre',
    timestamps: false
  });

  Genre.associate = function(models) {
    models.Genre.hasMany(models.Movie,{
      foreignKey: 'genre_id'});
  };

  return Genre;
};
