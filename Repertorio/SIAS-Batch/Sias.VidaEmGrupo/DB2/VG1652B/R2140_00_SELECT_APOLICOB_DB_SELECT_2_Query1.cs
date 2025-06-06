using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1652B
{
    public class R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1 : QueryBasis<R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(PRM_TARIFARIO_IX)
            INTO :APOLICOB-PRM-TARIFARIO-IX
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(PRM_TARIFARIO_IX)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											AND RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											WITH UR";

            return query;
        }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1 Execute(R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1 r2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1)
        {
            var ths = r2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1();
            var i = 0;
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}