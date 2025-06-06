using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1 : QueryBasis<M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_QUITACAO ,
            VAL_RCAP ,
            DATA_MOVIMENTO,
            SITUACAO
            INTO :BILHETE-DATA-QUITACAO ,
            :BILHETE-VAL-RCAP ,
            :BILHETE-DATA-MOVIMENTO ,
            :BILHETE-SITUACAO
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE = :PROPOFID-NUM-SICOB
            AND SITUACAO <> 'R'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_QUITACAO 
							,
											VAL_RCAP 
							,
											DATA_MOVIMENTO
							,
											SITUACAO
											FROM SEGUROS.BILHETE
											WHERE NUM_BILHETE = '{this.PROPOFID_NUM_SICOB}'
											AND SITUACAO <> 'R'
											WITH UR";

            return query;
        }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_DATA_MOVIMENTO { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }

        public static M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1 Execute(M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1 m_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1)
        {
            var ths = m_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.BILHETE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}