using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6254B
{
    public class R0510_00_SELECT_AU085_DB_SELECT_1_Query1 : QueryBasis<R0510_00_SELECT_AU085_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_FONTE ,
            A.NUM_PROPOSTA ,
            A.COD_PRODUTO ,
            B.NUM_TOKEN_PGTO
            INTO :PROPOSTA-COD-FONTE ,
            :PROPOSTA-NUM-PROPOSTA ,
            :ENDOSSOS-COD-PRODUTO ,
            :AU085-NUM-TOKEN-PGTO
            FROM SEGUROS.PROPOSTAS A,
            SEGUROS.AU_PROPOSTA_COMPL B
            WHERE A.COD_FONTE = :PROPOSTA-COD-FONTE
            AND A.NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA
            AND A.COD_FONTE = B.COD_FONTE
            AND A.NUM_PROPOSTA = B.NUM_PROPOSTA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_FONTE 
							,
											A.NUM_PROPOSTA 
							,
											A.COD_PRODUTO 
							,
											B.NUM_TOKEN_PGTO
											FROM SEGUROS.PROPOSTAS A
							,
											SEGUROS.AU_PROPOSTA_COMPL B
											WHERE A.COD_FONTE = '{this.PROPOSTA_COD_FONTE}'
											AND A.NUM_PROPOSTA = '{this.PROPOSTA_NUM_PROPOSTA}'
											AND A.COD_FONTE = B.COD_FONTE
											AND A.NUM_PROPOSTA = B.NUM_PROPOSTA
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PROPOSTA_COD_FONTE { get; set; }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string AU085_NUM_TOKEN_PGTO { get; set; }

        public static R0510_00_SELECT_AU085_DB_SELECT_1_Query1 Execute(R0510_00_SELECT_AU085_DB_SELECT_1_Query1 r0510_00_SELECT_AU085_DB_SELECT_1_Query1)
        {
            var ths = r0510_00_SELECT_AU085_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0510_00_SELECT_AU085_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0510_00_SELECT_AU085_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOSTA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.AU085_NUM_TOKEN_PGTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}