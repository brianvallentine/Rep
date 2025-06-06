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
    public class R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(SEQ_APOLICE) + 1
            INTO :APOLICES-NUM-APOLICE
            FROM SEGUROS.NUMERO_AES
            WHERE ORGAO_EMISSOR = :FONTES-ORGAO-EMISSOR
            AND RAMO_EMISSOR = :RAMOCOMP-RAMO-EMISSOR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(SEQ_APOLICE) + 1
											FROM SEGUROS.NUMERO_AES
											WHERE ORGAO_EMISSOR = '{this.FONTES_ORGAO_EMISSOR}'
											AND RAMO_EMISSOR = '{this.RAMOCOMP_RAMO_EMISSOR}'";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string RAMOCOMP_RAMO_EMISSOR { get; set; }
        public string FONTES_ORGAO_EMISSOR { get; set; }

        public static R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1 Execute(R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1 r8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}