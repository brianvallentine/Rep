using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1110B
{
    public class P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1 : QueryBasis<P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PESFONE.DDD
            ,PESFONE.NUM_FONE
            INTO :DDD
            ,:NUM-FONE
            FROM SEGUROS.PESSOA_TELEFONE PESFONE
            WHERE PESFONE.COD_PESSOA = :PROPOFID-COD-PESSOA
            AND PESFONE.TIPO_FONE IN (3, 4)
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PESFONE.DDD
											,PESFONE.NUM_FONE
											FROM SEGUROS.PESSOA_TELEFONE PESFONE
											WHERE PESFONE.COD_PESSOA = '{this.PROPOFID_COD_PESSOA}'
											AND PESFONE.TIPO_FONE IN (3
							, 4)
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string DDD { get; set; }
        public string NUM_FONE { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1 Execute(P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1 p2220_BUSCA_TELEFONE_DB_SELECT_1_Query1)
        {
            var ths = p2220_BUSCA_TELEFONE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1();
            var i = 0;
            dta.DDD = result[i++].Value?.ToString();
            dta.NUM_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}