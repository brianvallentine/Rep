using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1 : QueryBasis<M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-COUNTERRO-OPC
            FROM SEGUROS.VG_CRITICA_PROPOSTA
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND COD_MSG_CRITICA IN (2001, 2003, 2402, 2501, 2502,
            2503, 2504, 2505, 2506, 3001, 3002)
            AND STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.VG_CRITICA_PROPOSTA
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND COD_MSG_CRITICA IN (2001
							, 2003
							, 2402
							, 2501
							, 2502
							,
											2503
							, 2504
							, 2505
							, 2506
							, 3001
							, 3002)
											AND STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											WITH UR";

            return query;
        }
        public string WS_COUNTERRO_OPC { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1 Execute(M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1 m_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1)
        {
            var ths = m_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNTERRO_OPC = result[i++].Value?.ToString();
            return dta;
        }

    }
}