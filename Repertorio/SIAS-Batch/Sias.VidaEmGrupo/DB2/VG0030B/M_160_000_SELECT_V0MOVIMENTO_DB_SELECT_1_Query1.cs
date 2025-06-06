using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WHOST-COUNT-MOV
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO
            AND DATA_INCLUSAO IS NULL
            AND ((COD_OPERACAO < 0300) OR
            (COD_OPERACAO > 0499 AND
            COD_OPERACAO < 0800))
            AND DATA_MOVIMENTO < '9999-12-31'
            AND SIT_REGISTRO <> '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											AND DATA_INCLUSAO IS NULL
											AND ((COD_OPERACAO < 0300) OR
											(COD_OPERACAO > 0499 AND
											COD_OPERACAO < 0800))
											AND DATA_MOVIMENTO < '9999-12-31'
											AND SIT_REGISTRO <> '1'
											WITH UR";

            return query;
        }
        public string WHOST_COUNT_MOV { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1 Execute(M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1 m_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT_MOV = result[i++].Value?.ToString();
            return dta;
        }

    }
}