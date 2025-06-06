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
    public class M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1 : QueryBasis<M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            , SIT_REGISTRO
            INTO :WNUM-CERTIFICADO
            , :WSIT-REGISTRO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_APOLICE = :MNUM-APOLICE
            AND COD_SUBGRUPO = :WCOD-SUBGRUPO-EMP
            ORDER BY DATA_MOVIMENTO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											, SIT_REGISTRO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_APOLICE = '{this.MNUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.WCOD_SUBGRUPO_EMP}'
											ORDER BY DATA_MOVIMENTO
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WNUM_CERTIFICADO { get; set; }
        public string WSIT_REGISTRO { get; set; }
        public string WCOD_SUBGRUPO_EMP { get; set; }
        public string MNUM_APOLICE { get; set; }

        public static M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1 Execute(M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1 m_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1)
        {
            var ths = m_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1();
            var i = 0;
            dta.WNUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.WSIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}