module.exports = (app, db) => {
    app.get( "/api/dvds", (req, res) =>
        db.DVD.findAll({
          include: [{ all: true, nested: true }]
      })
        .then( (result) => res.json(result) )
    );
  
    app.get( "/api/dvd/:id", (req, res) =>
      db.DVD.findByPk(req.params.id,
        {
          include: [{ all: true, nested: true }]
        })
      .then( (result) => res.json(result))
    );
  
    app.post("/api/dvd", (req, res) => 
      db.DVD.create({
        dvd_id: req.body.dvd_id,
        movie_id: req.body.movie_id,
        isbn: req.body.isbn,
        edition: req.body.edition,
        region: req.body.region

      }).then( (result) => res.json(result) )
    );
  
    app.put( "/api/dvd/:id", (req, res) =>
      db.DVD.update({
        movie_id: req.body.movie_id,
        isbn: req.body.isbn,
        edition: req.body.edition,
        region: req.body.regionnpm
      },
      {
        where: {
          id: req.params.id
        }
      }).then( (result) => res.json(result) )
    );
  
    app.delete( "/api/dvd/:id", (req, res) =>
      db.DVD.destroy({
        where: {
          dvd_id: req.params.id
        }
      }).then( (result) => res.json(result) )
    );
  }