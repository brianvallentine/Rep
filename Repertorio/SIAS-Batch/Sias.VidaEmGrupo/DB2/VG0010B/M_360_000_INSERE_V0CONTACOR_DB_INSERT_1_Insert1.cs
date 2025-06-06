using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1 : QueryBasis<M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.V0CONTACOR
            VALUES (:MCOD-CLIENTE,
            :MNUM-APOLICE,
            :MBCO-COBRANCA,
            :MAGE-COBRANCA,
            :MNUM-CTA-CORRENTE,
            :MDAC-CTA-CORRENTE,
            '0' ,
            :MNUM-CERTIFICADO,
            :MCOD-EMPRESA:WCOD-EMPRESA,
            :MAGE-COBRANCA:SQL-NOT-NULL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CONTACOR VALUES ({FieldThreatment(this.MCOD_CLIENTE)}, {FieldThreatment(this.MNUM_APOLICE)}, {FieldThreatment(this.MBCO_COBRANCA)}, {FieldThreatment(this.MAGE_COBRANCA)}, {FieldThreatment(this.MNUM_CTA_CORRENTE)}, {FieldThreatment(this.MDAC_CTA_CORRENTE)}, '0' , {FieldThreatment(this.MNUM_CERTIFICADO)},  {FieldThreatment((this.WCOD_EMPRESA?.ToInt() == -1 ? null : this.MCOD_EMPRESA))},  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : this.MAGE_COBRANCA))}, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string MCOD_CLIENTE { get; set; }
        public string MNUM_APOLICE { get; set; }
        public string MBCO_COBRANCA { get; set; }
        public string MAGE_COBRANCA { get; set; }
        public string MNUM_CTA_CORRENTE { get; set; }
        public string MDAC_CTA_CORRENTE { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MCOD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }
        public string SQL_NOT_NULL { get; set; }

        public static void Execute(M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1 m_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1)
        {
            var ths = m_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}