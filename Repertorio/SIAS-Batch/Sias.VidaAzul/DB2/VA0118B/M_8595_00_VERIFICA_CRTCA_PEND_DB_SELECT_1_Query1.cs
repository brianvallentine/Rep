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
    public class M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1 : QueryBasis<M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :WS-ERRO-COUNT
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
            AND B.COD_TP_MSG_CRITICA <> 3
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
											AND B.COD_TP_MSG_CRITICA <> 3
											WITH UR";

            return query;
        }
        public string WS_ERRO_COUNT { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1 Execute(M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1 m_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1)
        {
            var ths = m_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_ERRO_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}