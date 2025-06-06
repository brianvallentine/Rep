using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 : QueryBasis<M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COBERAPOL
            VALUES (:PROPVA-NUM-APOLICE,
            0,
            :WHOST-NUM-ITEM,
            :SEGURVGA-OCORR-HISTORICO,
            :APOLICES-RAMO-EMISSOR,
            :APOLICES-COD-MODALIDADE,
            11,
            :PLAVAVGA-IMPMORNATU,
            :PLAVAVGA-VLPREMIOTOT,
            :PLAVAVGA-IMPMORNATU,
            :PLAVAVGA-VLPREMIOTOT,
            100,
            1,
            :PROPVA-DTQITBCO,
            :WHOST-DATA-TERVIGENCIA,
            NULL,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERAPOL VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, 0, {FieldThreatment(this.WHOST_NUM_ITEM)}, {FieldThreatment(this.SEGURVGA_OCORR_HISTORICO)}, {FieldThreatment(this.APOLICES_RAMO_EMISSOR)}, {FieldThreatment(this.APOLICES_COD_MODALIDADE)}, 11, {FieldThreatment(this.PLAVAVGA_IMPMORNATU)}, {FieldThreatment(this.PLAVAVGA_VLPREMIOTOT)}, {FieldThreatment(this.PLAVAVGA_IMPMORNATU)}, {FieldThreatment(this.PLAVAVGA_VLPREMIOTOT)}, 100, 1, {FieldThreatment(this.PROPVA_DTQITBCO)}, {FieldThreatment(this.WHOST_DATA_TERVIGENCIA)}, NULL, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string WHOST_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string PLAVAVGA_IMPMORNATU { get; set; }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string WHOST_DATA_TERVIGENCIA { get; set; }

        public static void Execute(M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 m_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1)
        {
            var ths = m_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}