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
    public class M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1 : QueryBasis<M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.STA_CRITICA
            INTO :WS-STA-CRITICA
            FROM SEGUROS.VG_CRITICA_PROPOSTA A
            WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND A.COD_MSG_CRITICA = :WS-COD-ERRO-DPS
            ORDER BY A.DTH_CADASTRAMENTO DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.STA_CRITICA
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
											WHERE A.NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND A.COD_MSG_CRITICA = '{this.WS_COD_ERRO_DPS}'
											ORDER BY A.DTH_CADASTRAMENTO DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WS_STA_CRITICA { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string WS_COD_ERRO_DPS { get; set; }

        public static M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1 Execute(M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1 m_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1)
        {
            var ths = m_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_STA_CRITICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}