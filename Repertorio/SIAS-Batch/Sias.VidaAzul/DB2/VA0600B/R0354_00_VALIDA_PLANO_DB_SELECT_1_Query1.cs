using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1 : QueryBasis<R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            CODSUBES ,
            VLPREMIOTOT
            INTO :WHOST-APOLICE-PLANO ,
            :WHOST-CODSUBES-PLANO ,
            :PLAVAVGA-VLPREMIOTOT
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :VG130-NUM-APOLICE
            AND CODSUBES = :VG130-COD-SUBGRUPO
            AND OPCAO_COBER = :WHOST-OPCAO-COBER
            AND ((:WHOST-DATA-PROPOSTA BETWEEN
            DTINIVIG AND DTTERVIG)
            OR (:WHOST-DATA-QUITACAO BETWEEN
            DTINIVIG AND DTTERVIG))
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											CODSUBES 
							,
											VLPREMIOTOT
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.VG130_NUM_APOLICE}'
											AND CODSUBES = '{this.VG130_COD_SUBGRUPO}'
											AND OPCAO_COBER = '{this.WHOST_OPCAO_COBER}'
											AND (('{this.WHOST_DATA_PROPOSTA}' BETWEEN
											DTINIVIG AND DTTERVIG)
											OR ('{this.WHOST_DATA_QUITACAO}' BETWEEN
											DTINIVIG AND DTTERVIG))
											WITH UR";

            return query;
        }
        public string WHOST_APOLICE_PLANO { get; set; }
        public string WHOST_CODSUBES_PLANO { get; set; }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string WHOST_DATA_PROPOSTA { get; set; }
        public string WHOST_DATA_QUITACAO { get; set; }
        public string VG130_COD_SUBGRUPO { get; set; }
        public string VG130_NUM_APOLICE { get; set; }
        public string WHOST_OPCAO_COBER { get; set; }

        public static R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1 Execute(R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1 r0354_00_VALIDA_PLANO_DB_SELECT_1_Query1)
        {
            var ths = r0354_00_VALIDA_PLANO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_APOLICE_PLANO = result[i++].Value?.ToString();
            dta.WHOST_CODSUBES_PLANO = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLPREMIOTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}