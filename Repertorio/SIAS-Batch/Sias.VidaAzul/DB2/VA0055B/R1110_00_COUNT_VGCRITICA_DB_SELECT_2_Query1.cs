using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0055B
{
    public class R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1 : QueryBasis<R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT-1800
            FROM SEGUROS.VG_CRITICA_PROPOSTA B,
            SEGUROS.PROPOSTA_FIDELIZ D
            WHERE B.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND SUBSTR(B.NUM_CERTIFICADO,1,1) = 3
            AND B.COD_MSG_CRITICA = 1800
            AND B.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND B.NUM_CERTIFICADO = D.NUM_PROPOSTA_SIVPF
            AND D.COD_PRODUTO_SIVPF = 11
            AND B.NUM_CERTIFICADO =
            (SELECT C.NUM_CERTIFICADO
            FROM SEGUROS.VG_COMPL_SICAQWEB C
            WHERE C.NUM_CERTIFICADO = B.NUM_CERTIFICADO)
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.VG_CRITICA_PROPOSTA B
							,
											SEGUROS.PROPOSTA_FIDELIZ D
											WHERE B.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND SUBSTR(B.NUM_CERTIFICADO
							,1
							,1) = 3
											AND B.COD_MSG_CRITICA = 1800
											AND B.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND B.NUM_CERTIFICADO = D.NUM_PROPOSTA_SIVPF
											AND D.COD_PRODUTO_SIVPF = 11
											AND B.NUM_CERTIFICADO =
											(SELECT C.NUM_CERTIFICADO
											FROM SEGUROS.VG_COMPL_SICAQWEB C
											WHERE C.NUM_CERTIFICADO = B.NUM_CERTIFICADO)
											WITH UR";

            return query;
        }
        public string WHOST_COUNT_1800 { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1 Execute(R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1 r1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1)
        {
            var ths = r1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_COUNT_1800 = result[i++].Value?.ToString();
            return dta;
        }

    }
}