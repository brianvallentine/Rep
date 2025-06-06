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
    public class P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1 : QueryBasis<P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GEPESTEL.NUM_TELEFONE
            ,GEPESTEL.NUM_DDD
            INTO :GEPESTEL-NUM-TELEFONE
            ,:GEPESTEL-NUM-DDD
            FROM SEGUROS.GE_PESSOA_TELEFONE GEPESTEL
            WHERE GEPESTEL.COD_PESSOA = :GEPESSOA-COD-PESSOA
            AND SUBSTR(CHAR(GEPESTEL.NUM_TELEFONE),1,1) IN
            ( '7' , '8' , '9' )
            AND GEPESTEL.SEQ_TELEFONE =
            (SELECT MAX(GEPESTELB.SEQ_TELEFONE)
            FROM SEGUROS.GE_PESSOA_TELEFONE GEPESTELB
            WHERE GEPESTELB.COD_PESSOA =
            GEPESTEL.COD_PESSOA
            AND SUBSTR(CHAR(GEPESTELB.NUM_TELEFONE),1,1)
            IN ( '7' , '8' , '9' ))
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT GEPESTEL.NUM_TELEFONE
											,GEPESTEL.NUM_DDD
											FROM SEGUROS.GE_PESSOA_TELEFONE GEPESTEL
											WHERE GEPESTEL.COD_PESSOA = '{this.GEPESSOA_COD_PESSOA}'
											AND SUBSTR(CHAR(GEPESTEL.NUM_TELEFONE)
							,1
							,1) IN
											( '7' 
							, '8' 
							, '9' )
											AND GEPESTEL.SEQ_TELEFONE =
											(SELECT MAX(GEPESTELB.SEQ_TELEFONE)
											FROM SEGUROS.GE_PESSOA_TELEFONE GEPESTELB
											WHERE GEPESTELB.COD_PESSOA =
											GEPESTEL.COD_PESSOA
											AND SUBSTR(CHAR(GEPESTELB.NUM_TELEFONE)
							,1
							,1)
											IN ( '7' 
							, '8' 
							, '9' ))
											WITH UR";

            return query;
        }
        public string GEPESTEL_NUM_TELEFONE { get; set; }
        public string GEPESTEL_NUM_DDD { get; set; }
        public string GEPESSOA_COD_PESSOA { get; set; }

        public static P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1 Execute(P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1 p2430_BUSCA_TELEFONE_DB_SELECT_1_Query1)
        {
            var ths = p2430_BUSCA_TELEFONE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEPESTEL_NUM_TELEFONE = result[i++].Value?.ToString();
            dta.GEPESTEL_NUM_DDD = result[i++].Value?.ToString();
            return dta;
        }

    }
}