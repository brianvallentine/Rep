using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1 : QueryBasis<M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_PAGAMENTO
            INTO :OPCPAGVI-PERI-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO-RISCO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PERI_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.WS_NUM_CERTIFICADO_RISCO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string WS_NUM_CERTIFICADO_RISCO { get; set; }

        public static M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1 Execute(M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1 m_0282_00_VERIFICA_PU_DB_SELECT_1_Query1)
        {
            var ths = m_0282_00_VERIFICA_PU_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0282_00_VERIFICA_PU_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}