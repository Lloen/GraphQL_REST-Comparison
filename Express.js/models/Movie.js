/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
  const Movie = sequelize.define('Movie', {
    movie_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    movie_title: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    length: {
      type: DataTypes.INTEGER,
      allowNull: false
    },
    genre_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'Genre',
        key: 'genre_id'
      }
    },
    release_date: {
      type: DataTypes.TEXT,
      allowNull: false
    }
  }, {
    tableName: 'Movie',
    timestamps: false
  });

  Movie.associate = function(models) {
    models.Movie.hasMany(models.DVD,{
      foreignKey: 'movie_id'});
    models.Movie.belongsTo(models.Genre,
        { foreignKey: "genre_id" });
  };

  return Movie;
};
