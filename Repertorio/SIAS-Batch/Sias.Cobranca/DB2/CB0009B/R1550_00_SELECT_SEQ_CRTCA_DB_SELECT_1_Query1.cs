using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1 : QueryBasis<R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(A.SEQ_CRITICA, 0)
            INTO :WS-SEQ-CRITICA
            FROM SEGUROS.VG_CRITICA_PROPOSTA A
            WHERE A.NUM_CERTIFICADO = :V0ERRO-NUMBIL
            AND A.COD_MSG_CRITICA = :V0ERRO-CODERRO
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(A.SEQ_CRITICA
							, 0)
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
											WHERE A.NUM_CERTIFICADO = '{this.V0ERRO_NUMBIL}'
											AND A.COD_MSG_CRITICA = '{this.V0ERRO_CODERRO}'
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											WITH UR";

            return query;
        }
        public string WS_SEQ_CRITICA { get; set; }
        public string V0ERRO_CODERRO { get; set; }
        public string V0ERRO_NUMBIL { get; set; }

        public static R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1 Execute(R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1 r1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1)
        {
            var ths = r1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_SEQ_CRITICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}