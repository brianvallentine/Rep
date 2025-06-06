using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R1100_00_LER_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LER_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_QUITACAO ,
            VAL_RCAP ,
            DATA_MOVIMENTO,
            SITUACAO
            INTO :DCLBILHETE.BILHETE-DATA-QUITACAO ,
            :DCLBILHETE.BILHETE-VAL-RCAP ,
            :DCLBILHETE.BILHETE-DATA-MOVIMENTO,
            :DCLBILHETE.BILHETE-SITUACAO
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE = :DCLBILHETE.BILHETE-NUM-BILHETE
            AND SITUACAO <> 'R'
            WITH UR
            END-EXEC.
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
											WHERE NUM_BILHETE = '{this.BILHETE_NUM_BILHETE}'
											AND SITUACAO <> 'R'
											WITH UR";

            return query;
        }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_DATA_MOVIMENTO { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R1100_00_LER_BILHETE_DB_SELECT_1_Query1 Execute(R1100_00_LER_BILHETE_DB_SELECT_1_Query1 r1100_00_LER_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LER_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LER_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LER_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.BILHETE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}