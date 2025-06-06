using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0445B
{
    public class R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1 : QueryBasis<R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(A.COD_MSG_CRITICA)
            INTO :WS-COUNT
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :WHOST-NRCERTIF
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA
            AND B.COD_TP_MSG_CRITICA <> '3'
            AND VALUE(B.COD_AGRUPA_ERRO, ' ' ) <> 'CAD'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(A.COD_MSG_CRITICA)
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.WHOST_NRCERTIF}'
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA
											AND B.COD_TP_MSG_CRITICA <> '3'
											AND VALUE(B.COD_AGRUPA_ERRO
							, ' ' ) <> 'CAD'
											WITH UR";

            return query;
        }
        public string WS_COUNT { get; set; }
        public string WHOST_NRCERTIF { get; set; }

        public static R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1 Execute(R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1 r2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1)
        {
            var ths = r2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}