using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1 : QueryBasis<DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BCO_AVISO ,
            AGE_AVISO ,
            NUM_AVISO_CREDITO ,
            DATA_RCAP
            INTO :RCAPCOMP-BCO-AVISO ,
            :RCAPCOMP-AGE-AVISO ,
            :RCAPCOMP-NUM-AVISO-CREDITO,
            :RCAPCOMP-DATA-RCAP
            FROM SEGUROS.RCAP_COMPLEMENTAR
            WHERE COD_FONTE = :RCAPS-COD-FONTE
            AND NUM_RCAP = :RCAPS-NUM-RCAP
            AND NUM_RCAP_COMPLEMEN = 0
            AND SIT_REGISTRO = '0'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT BCO_AVISO 
							,
											AGE_AVISO 
							,
											NUM_AVISO_CREDITO 
							,
											DATA_RCAP
											FROM SEGUROS.RCAP_COMPLEMENTAR
											WHERE COD_FONTE = '{this.RCAPS_COD_FONTE}'
											AND NUM_RCAP = '{this.RCAPS_NUM_RCAP}'
											AND NUM_RCAP_COMPLEMEN = 0
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1 Execute(DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1 dB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1)
        {
            var ths = dB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}