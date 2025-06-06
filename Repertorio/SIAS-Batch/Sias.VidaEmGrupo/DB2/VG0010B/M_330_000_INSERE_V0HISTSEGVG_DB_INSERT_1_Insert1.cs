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
    public class M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1 : QueryBasis<M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.V0HISTSEGVG
            VALUES (:MNUM-APOLICE,
            :MCOD-SUBGRUPO,
            :SNUM-ITEM,
            :MCOD-OPERACAO,
            :V1SISTEMA-DTMOVABE,
            :HHORA-OPERACAO,
            :MDATA-MOVIMENTO:WDATA-MOVIMENTO,
            :HOCORR-HISTORICO,
            :HCOD-SUBGRUP-TRANS,
            :MDATA-REFERENCIA:WDATA-REFERENCIA,
            :MCOD-USUARIO,
            :MCOD-EMPRESA:WCOD-EMPRESA,
            :V1EN-COD-MOEDA-IMP:WCOD-MOEDA,
            :V1EN-COD-MOEDA-PRM:WCOD-MOEDA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTSEGVG VALUES ({FieldThreatment(this.MNUM_APOLICE)}, {FieldThreatment(this.MCOD_SUBGRUPO)}, {FieldThreatment(this.SNUM_ITEM)}, {FieldThreatment(this.MCOD_OPERACAO)}, {FieldThreatment(this.V1SISTEMA_DTMOVABE)}, {FieldThreatment(this.HHORA_OPERACAO)},  {FieldThreatment((this.WDATA_MOVIMENTO?.ToInt() == -1 ? null : this.MDATA_MOVIMENTO))}, {FieldThreatment(this.HOCORR_HISTORICO)}, {FieldThreatment(this.HCOD_SUBGRUP_TRANS)},  {FieldThreatment((this.WDATA_REFERENCIA?.ToInt() == -1 ? null : this.MDATA_REFERENCIA))}, {FieldThreatment(this.MCOD_USUARIO)},  {FieldThreatment((this.WCOD_EMPRESA?.ToInt() == -1 ? null : this.MCOD_EMPRESA))},  {FieldThreatment((this.WCOD_MOEDA?.ToInt() == -1 ? null : this.V1EN_COD_MOEDA_IMP))},  {FieldThreatment((this.WCOD_MOEDA?.ToInt() == -1 ? null : this.V1EN_COD_MOEDA_PRM))})";

            return query;
        }
        public string MNUM_APOLICE { get; set; }
        public string MCOD_SUBGRUPO { get; set; }
        public string SNUM_ITEM { get; set; }
        public string MCOD_OPERACAO { get; set; }
        public string V1SISTEMA_DTMOVABE { get; set; }
        public string HHORA_OPERACAO { get; set; }
        public string MDATA_MOVIMENTO { get; set; }
        public string WDATA_MOVIMENTO { get; set; }
        public string HOCORR_HISTORICO { get; set; }
        public string HCOD_SUBGRUP_TRANS { get; set; }
        public string MDATA_REFERENCIA { get; set; }
        public string WDATA_REFERENCIA { get; set; }
        public string MCOD_USUARIO { get; set; }
        public string MCOD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }
        public string V1EN_COD_MOEDA_IMP { get; set; }
        public string WCOD_MOEDA { get; set; }
        public string V1EN_COD_MOEDA_PRM { get; set; }

        public static void Execute(M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1 m_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1)
        {
            var ths = m_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}