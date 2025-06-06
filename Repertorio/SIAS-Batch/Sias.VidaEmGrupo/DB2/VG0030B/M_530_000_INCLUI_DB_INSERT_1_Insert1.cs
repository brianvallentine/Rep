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
    public class M_530_000_INCLUI_DB_INSERT_1_Insert1 : QueryBasis<M_530_000_INCLUI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.V0HISTCONTABILVA
            VALUES (:MNUM-CERTIFICADO,
            :V0PROP-NRPARCELA,
            :V0HCOB-NRTIT,
            :V0HCOB-OCORHIST,
            :MNUM-APOLICE,
            :MCOD-SUBGRUPO,
            :MCOD-FONTE,
            0,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0HCOB-DTVENCTO,
            '0' ,
            :MCOD-OPERACAO,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES ({FieldThreatment(this.MNUM_CERTIFICADO)}, {FieldThreatment(this.V0PROP_NRPARCELA)}, {FieldThreatment(this.V0HCOB_NRTIT)}, {FieldThreatment(this.V0HCOB_OCORHIST)}, {FieldThreatment(this.MNUM_APOLICE)}, {FieldThreatment(this.MCOD_SUBGRUPO)}, {FieldThreatment(this.MCOD_FONTE)}, 0, {FieldThreatment(this.V0PARC_PRMVG)}, {FieldThreatment(this.V0PARC_PRMAP)}, {FieldThreatment(this.V0HCOB_DTVENCTO)}, '0' , {FieldThreatment(this.MCOD_OPERACAO)}, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0PROP_NRPARCELA { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string MNUM_APOLICE { get; set; }
        public string MCOD_SUBGRUPO { get; set; }
        public string MCOD_FONTE { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string MCOD_OPERACAO { get; set; }

        public static void Execute(M_530_000_INCLUI_DB_INSERT_1_Insert1 m_530_000_INCLUI_DB_INSERT_1_Insert1)
        {
            var ths = m_530_000_INCLUI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_530_000_INCLUI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}