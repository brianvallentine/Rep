using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0220_00_LER_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0220_00_LER_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_BILHETE,
            NUM_APOLICE,
            NUM_APOL_ANTERIOR,
            OPC_COBERTURA,
            DATA_QUITACAO,
            VAL_RCAP,
            RAMO,
            SITUACAO
            INTO :DCLBILHETE.BILHETE-NUM-BILHETE,
            :DCLBILHETE.BILHETE-NUM-APOLICE,
            :DCLBILHETE.BILHETE-NUM-APOL-ANTERIOR,
            :DCLBILHETE.BILHETE-OPC-COBERTURA,
            :DCLBILHETE.BILHETE-DATA-QUITACAO,
            :DCLBILHETE.BILHETE-VAL-RCAP,
            :DCLBILHETE.BILHETE-RAMO,
            :DCLBILHETE.BILHETE-SITUACAO
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE = :DCLBILHETE.BILHETE-NUM-BILHETE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_BILHETE
							,
											NUM_APOLICE
							,
											NUM_APOL_ANTERIOR
							,
											OPC_COBERTURA
							,
											DATA_QUITACAO
							,
											VAL_RCAP
							,
											RAMO
							,
											SITUACAO
											FROM SEGUROS.BILHETE
											WHERE NUM_BILHETE = '{this.BILHETE_NUM_BILHETE}'
											WITH UR";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_SITUACAO { get; set; }

        public static R0220_00_LER_BILHETE_DB_SELECT_1_Query1 Execute(R0220_00_LER_BILHETE_DB_SELECT_1_Query1 r0220_00_LER_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0220_00_LER_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0220_00_LER_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0220_00_LER_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();
            dta.BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}