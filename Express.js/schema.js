const graphql = require('graphql')
const { GraphQLSchema, GraphQLObjectType, GraphQLString, GraphQLList, GraphQLInt } = graphql
const db = require('./models');

const dvds = db.DVD.findAll({
    include: [{ all: true, nested: true }]
});

const movies = db.Movie.findAll({
    include: [{ all: true, nested: true }]
});

const genreType =  new GraphQLObjectType({
    name: 'Genre',
    fields: {
        genre_id: {
        type: GraphQLInt
      },
      genre: {
        type: GraphQLString
      }
    }
  })


const movieType =  new GraphQLObjectType({
    name: 'Movie',
    fields: {
        movie_id: {
        type: GraphQLInt
      },
      movie_title: {
        type: GraphQLString
      },
      length: {
        type: GraphQLInt
      },
      genre_id: {
        type: GraphQLInt
      },
      release_date: {
        type: GraphQLString
      },
      Genre: {
        type: genreType
      }
    }
  })

const dvdType =  new GraphQLObjectType({
    name: 'DVD',
    fields: {
        dvd_id: {
        type: GraphQLInt
      },
      movie_id: {
        type: GraphQLInt
      },
      isbn: {
        type: GraphQLString
      },
      edition: {
        type: GraphQLString
      },
      region: {
        type: GraphQLString
      },
      Movie: {
        type: movieType
      }
    }
  })

  const queryType =  new GraphQLObjectType({
    name: 'Query',
    fields: {
      getDvd: {
        type: dvdType,
        args: {
          id: { type: GraphQLInt }
        },
        resolve: (source, {id}) => {
          return dvds[id]
        }
      },
      getDvDs: {
        type: new GraphQLList(dvdType),
        resolve: () => {
          return dvds
        }
      }
    }
  })
  
  const mutationType =  new GraphQLObjectType({
    name: 'Mutation',
    fields: {
      createDvd: {
        type: dvdType,
        args: {
          dvd_id: { type: GraphQLInt },
          movie_id: { type: GraphQLInt },
          isbn: { type: GraphQLString },
          edition: { type: GraphQLString },
          region: { type: GraphQLString },
        },
        resolve: async (rootValue, input) => {
            db.DVD.create({
                dvd_id: input.dvd_id,
                movie_id: input.movie_id,
                isbn: input.isbn,
                edition: input.edition,
                region: input.region        
              })
            return dvds
        }
      },
      deleteDvD: {
        type: dvdType,
        args: {
          dvd_id: { type: GraphQLInt }
        },
        resolve: async (rootValue, input) => {
          db.DVD.destroy({
            where: {
              dvd_id: input.dvd_id
            }
          })
          return dvds
        }
      }
    }
  })


const schema = new GraphQLSchema({
    query: queryType,
    mutation: mutationType
  })

module.exports = schema