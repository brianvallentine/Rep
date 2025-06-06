using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4437B
{
    public class R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1 : QueryBasis<R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            FATOR_MULTIPLICA
            INTO :APOLICOB-IMP-SEGURADA-AMDS,
            :APOLICOB-FATOR-MULTIPLICA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO =
            :SEGURVGA-OCORR-HISTORICO
            AND RAMO_COBERTURA IN (81, 82)
            AND COD_COBERTURA = 03
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											FATOR_MULTIPLICA
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO =
											'{this.SEGURVGA_OCORR_HISTORICO}'
											AND RAMO_COBERTURA IN (81
							, 82)
											AND COD_COBERTURA = 03";

            return query;
        }
        public string APOLICOB_IMP_SEGURADA_AMDS { get; set; }
        public string APOLICOB_FATOR_MULTIPLICA { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1 Execute(R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1 r2200_00_PROCESSA_FAC_DB_SELECT_6_Query1)
        {
            var ths = r2200_00_PROCESSA_FAC_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1();
            var i = 0;
            dta.APOLICOB_IMP_SEGURADA_AMDS = result[i++].Value?.ToString();
            dta.APOLICOB_FATOR_MULTIPLICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}