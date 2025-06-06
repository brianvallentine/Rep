using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE,
            NRENDOS,
            NUM_ITEM,
            OCORHIST,
            RAMOFR,
            MODALIFR,
            COD_COBERTURA,
            IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX,
            FATOR_MULTIPLICA,
            DATA_INIVIGENCIA
            INTO
            :CNUM-APOLICE,
            :CNRENDOS,
            :CNUM-ITEM,
            :COCORHIST,
            :CRAMOFR,
            :CMODALIFR,
            :CCOD-COBERTURA,
            :CIMP-SEGURADA-IX,
            :CPRM-TARIFARIO-IX,
            :CFATOR-MULTIPLICA,
            :CDATA-INIVIGENCIA
            FROM
            SEGUROS.V1COBERAPOL
            WHERE
            NUM_APOLICE = :CNUM-APOLICE AND
            NRENDOS = 0 AND
            NUM_ITEM = :CNUM-ITEM AND
            OCORHIST = :COCORHIST AND
            MODALIFR = 0 AND
            COD_COBERTURA = :CCOD-COBERTURA AND
            RAMOFR = :CRAMOFR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											NRENDOS
							,
											NUM_ITEM
							,
											OCORHIST
							,
											RAMOFR
							,
											MODALIFR
							,
											COD_COBERTURA
							,
											IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
							,
											FATOR_MULTIPLICA
							,
											DATA_INIVIGENCIA
											FROM
											SEGUROS.V1COBERAPOL
											WHERE
											NUM_APOLICE = '{this.CNUM_APOLICE}' AND
											NRENDOS = 0 AND
											NUM_ITEM = '{this.CNUM_ITEM}' AND
											OCORHIST = '{this.COCORHIST}' AND
											MODALIFR = 0 AND
											COD_COBERTURA = '{this.CCOD_COBERTURA}' AND
											RAMOFR = '{this.CRAMOFR}'";

            return query;
        }
        public string CNUM_APOLICE { get; set; }
        public string CNRENDOS { get; set; }
        public string CNUM_ITEM { get; set; }
        public string COCORHIST { get; set; }
        public string CRAMOFR { get; set; }
        public string CMODALIFR { get; set; }
        public string CCOD_COBERTURA { get; set; }
        public string CIMP_SEGURADA_IX { get; set; }
        public string CPRM_TARIFARIO_IX { get; set; }
        public string CFATOR_MULTIPLICA { get; set; }
        public string CDATA_INIVIGENCIA { get; set; }

        public static M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 Execute(M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 m_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = m_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.CNUM_APOLICE = result[i++].Value?.ToString();
            dta.CNRENDOS = result[i++].Value?.ToString();
            dta.CNUM_ITEM = result[i++].Value?.ToString();
            dta.COCORHIST = result[i++].Value?.ToString();
            dta.CRAMOFR = result[i++].Value?.ToString();
            dta.CMODALIFR = result[i++].Value?.ToString();
            dta.CCOD_COBERTURA = result[i++].Value?.ToString();
            dta.CIMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.CPRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.CFATOR_MULTIPLICA = result[i++].Value?.ToString();
            dta.CDATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}