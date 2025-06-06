using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1 : QueryBasis<R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX,
            DATA_INIVIGENCIA
            INTO :APOLICOB-IMP-SEGURADA-IX,
            :APOLICOB-PRM-TARIFARIO-IX,
            :APOLICOB-DATA-INIVIGENCIA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            AND RAMO_COBERTURA = 93
            AND MODALI_COBERTURA = 0
            AND COD_COBERTURA = 11
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
							,
											DATA_INIVIGENCIA
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											AND RAMO_COBERTURA = 93
											AND MODALI_COBERTURA = 0
											AND COD_COBERTURA = 11";

            return query;
        }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1 Execute(R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1 r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1)
        {
            var ths = r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1();
            var i = 0;
            dta.APOLICOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}