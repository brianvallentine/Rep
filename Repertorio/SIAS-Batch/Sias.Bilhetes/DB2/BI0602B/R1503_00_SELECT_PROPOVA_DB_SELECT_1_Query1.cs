using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0602B
{
    public class R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1 : QueryBasis<R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_CERTIFICADO ,
            NUM_APOLICE ,
            COD_CLIENTE ,
            DATA_QUITACAO ,
            DATA_QUITACAO + 1 YEAR ,
            SIT_REGISTRO
            INTO
            :WS-HISTCON-NRCERTIF ,
            :WS-APOLICE-AUX ,
            :WS-CLIENTE-AUX ,
            :WS-DATA-QUITACAO-AUX ,
            :WS-PROXIMA-DT-QUIT ,
            :WS-SITUACAO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :WS-HISTCON-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CERTIFICADO 
							,
											NUM_APOLICE 
							,
											COD_CLIENTE 
							,
											DATA_QUITACAO 
							,
											DATA_QUITACAO + 1 YEAR 
							,
											SIT_REGISTRO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.WS_HISTCON_NRCERTIF}'";

            return query;
        }
        public string WS_HISTCON_NRCERTIF { get; set; }
        public string WS_APOLICE_AUX { get; set; }
        public string WS_CLIENTE_AUX { get; set; }
        public string WS_DATA_QUITACAO_AUX { get; set; }
        public string WS_PROXIMA_DT_QUIT { get; set; }
        public string WS_SITUACAO { get; set; }

        public static R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1 Execute(R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1 r1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1)
        {
            var ths = r1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HISTCON_NRCERTIF = result[i++].Value?.ToString();
            dta.WS_APOLICE_AUX = result[i++].Value?.ToString();
            dta.WS_CLIENTE_AUX = result[i++].Value?.ToString();
            dta.WS_DATA_QUITACAO_AUX = result[i++].Value?.ToString();
            dta.WS_PROXIMA_DT_QUIT = result[i++].Value?.ToString();
            dta.WS_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}