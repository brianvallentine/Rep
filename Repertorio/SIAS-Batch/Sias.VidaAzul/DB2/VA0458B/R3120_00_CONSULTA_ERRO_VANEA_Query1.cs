using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R3120_00_CONSULTA_ERRO_VANEA_Query1 : QueryBasis<R3120_00_CONSULTA_ERRO_VANEA_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-QTD-ERRO-VANEA
            FROM SEGUROS.PROPOSTAS_VA A
            WHERE A.NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND EXISTS
            ( SELECT 1
            FROM SEGUROS.VG_CRITICA_PROPOSTA V1,
            SEGUROS.VG_DM_MSG_CRITICA V2
            WHERE V1.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND V2.COD_MSG_CRITICA = V1.COD_MSG_CRITICA
            AND V2.COD_TP_MSG_CRITICA = 1
            )
            AND NOT EXISTS
            ( SELECT 1
            FROM SEGUROS.VG_CRITICA_PROPOSTA V5
            WHERE V5.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND V5.STA_CRITICA
            IN ( '0' , '1' , '2' , '3' , '4' , '5' , '8' )
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.PROPOSTAS_VA A
											WHERE A.NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND EXISTS
											( SELECT 1
											FROM SEGUROS.VG_CRITICA_PROPOSTA V1
							,
											SEGUROS.VG_DM_MSG_CRITICA V2
											WHERE V1.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND V2.COD_MSG_CRITICA = V1.COD_MSG_CRITICA
											AND V2.COD_TP_MSG_CRITICA = 1
											)
											AND NOT EXISTS
											( SELECT 1
											FROM SEGUROS.VG_CRITICA_PROPOSTA V5
											WHERE V5.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND V5.STA_CRITICA
											IN ( '0' 
							, '1' 
							, '2' 
							, '3' 
							, '4' 
							, '5' 
							, '8' )
											)";

            return query;
        }
        public string WS_QTD_ERRO_VANEA { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R3120_00_CONSULTA_ERRO_VANEA_Query1 Execute(R3120_00_CONSULTA_ERRO_VANEA_Query1 r3120_00_CONSULTA_ERRO_VANEA_Query1)
        {
            var ths = r3120_00_CONSULTA_ERRO_VANEA_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3120_00_CONSULTA_ERRO_VANEA_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3120_00_CONSULTA_ERRO_VANEA_Query1();
            var i = 0;
            dta.WS_QTD_ERRO_VANEA = result[i++].Value?.ToString();
            return dta;
        }

    }
}