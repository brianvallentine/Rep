using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1 : QueryBasis<R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(IMP_SEGURADA_IX,0),
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA
            INTO :OUTROCOB-IMP-SEGURADA-IX,
            :OUTROCOB-DATA-INIVIGENCIA,
            :OUTROCOB-DATA-TERVIGENCIA
            FROM SEGUROS.OUTROS_COBERTURAS
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE
            AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA
            AND DATA_INIVIGENCIA = (
            SELECT MAX(DATA_INIVIGENCIA)
            FROM SEGUROS.OUTROS_COBERTURAS
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE
            AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA
            )
            AND TIMESTAMP = (
            SELECT MAX(TIMESTAMP)
            FROM SEGUROS.OUTROS_COBERTURAS
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE
            AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA
            )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(IMP_SEGURADA_IX
							,0)
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.OUTROS_COBERTURAS
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											AND MODALI_COBERTURA = '{this.APOLICES_COD_MODALIDADE}'
											AND COD_COBERTURA = '{this.OUTROCOB_COD_COBERTURA}'
											AND DATA_INIVIGENCIA = (
											SELECT MAX(DATA_INIVIGENCIA)
											FROM SEGUROS.OUTROS_COBERTURAS
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											AND MODALI_COBERTURA = '{this.APOLICES_COD_MODALIDADE}'
											AND COD_COBERTURA = '{this.OUTROCOB_COD_COBERTURA}'
											)
											AND TIMESTAMP = (
											SELECT MAX(TIMESTAMP)
											FROM SEGUROS.OUTROS_COBERTURAS
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											AND MODALI_COBERTURA = '{this.APOLICES_COD_MODALIDADE}'
											AND COD_COBERTURA = '{this.OUTROCOB_COD_COBERTURA}'
											)
											WITH UR";

            return query;
        }
        public string OUTROCOB_IMP_SEGURADA_IX { get; set; }
        public string OUTROCOB_DATA_INIVIGENCIA { get; set; }
        public string OUTROCOB_DATA_TERVIGENCIA { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string OUTROCOB_COD_COBERTURA { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1 Execute(R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1 r710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1)
        {
            var ths = r710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1();
            var i = 0;
            dta.OUTROCOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.OUTROCOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.OUTROCOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}