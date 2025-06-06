using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.NUM_CERTIFICADO,
            T1.COD_CLIENTE,
            T1.OCOREND,
            T1.NUM_APOLICE
            INTO :PROPOVA-NUM-CERTIFICADO,
            :PROPOVA-COD-CLIENTE,
            :PROPOVA-OCOREND,
            :PROPOVA-NUM-APOLICE
            FROM SEGUROS.PROPOSTAS_VA T1
            WHERE T1.NUM_CERTIFICADO = :WSHOST-NUM-PROPOSTA
            AND T1.SIT_REGISTRO IN ( '3' , '6' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.NUM_CERTIFICADO
							,
											T1.COD_CLIENTE
							,
											T1.OCOREND
							,
											T1.NUM_APOLICE
											FROM SEGUROS.PROPOSTAS_VA T1
											WHERE T1.NUM_CERTIFICADO = '{this.WSHOST_NUM_PROPOSTA}'
											AND T1.SIT_REGISTRO IN ( '3' 
							, '6' )
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string WSHOST_NUM_PROPOSTA { get; set; }

        public static R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 r1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}