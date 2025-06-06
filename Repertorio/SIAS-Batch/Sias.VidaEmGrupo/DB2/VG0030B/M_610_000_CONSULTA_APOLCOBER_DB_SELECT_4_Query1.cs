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
    public class M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1 : QueryBasis<M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX
            INTO :MIMP-INVPERM-ATU
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :MNUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SNUM-ITEM
            AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP)
            AND MODALI_COBERTURA IN (0, :V0APOL-MODALIDA)
            AND COD_COBERTURA = 2
            AND DATA_INIVIGENCIA <= :MDATA-OPERACAO
            AND DATA_TERVIGENCIA >= :MDATA-OPERACAO
            FETCH FIRST 1 ROWS ONLY
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.MNUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SNUM_ITEM}'
											AND RAMO_COBERTURA IN (81
							, '{this.V1PAR_RAMO_AP}')
											AND MODALI_COBERTURA IN (0
							, '{this.V0APOL_MODALIDA}')
											AND COD_COBERTURA = 2
											AND DATA_INIVIGENCIA <= '{this.MDATA_OPERACAO}'
											AND DATA_TERVIGENCIA >= '{this.MDATA_OPERACAO}'
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string MIMP_INVPERM_ATU { get; set; }
        public string V0APOL_MODALIDA { get; set; }
        public string MDATA_OPERACAO { get; set; }
        public string V1PAR_RAMO_AP { get; set; }
        public string MNUM_APOLICE { get; set; }
        public string SNUM_ITEM { get; set; }

        public static M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1 Execute(M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1 m_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1)
        {
            var ths = m_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1();
            var i = 0;
            dta.MIMP_INVPERM_ATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}