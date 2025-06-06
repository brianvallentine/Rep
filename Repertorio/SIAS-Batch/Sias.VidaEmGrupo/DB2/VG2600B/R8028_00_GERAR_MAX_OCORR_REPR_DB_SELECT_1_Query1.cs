using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1 : QueryBasis<R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_HIST), 0) + 1
            INTO :VG093-NUM-OCORR-HIST
            FROM SEGUROS.VG_REPRES_LEGAL
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_HIST)
							, 0) + 1
											FROM SEGUROS.VG_REPRES_LEGAL
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string VG093_NUM_OCORR_HIST { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }

        public static R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1 Execute(R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1 r8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1)
        {
            var ths = r8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG093_NUM_OCORR_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}